if (!jQuery) { throw new Error("This plugin requires jQuery") }

(function (window) {
    'use strict';

    if (typeof (MonthDisplay) === 'undefined') {
        window.MonthDisplay = {
            Number: 0,
            FullName: 1,
            ShortName: 2
        };
    }
    var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "Octoper", "November", "December"];
    var monthShortNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    var defaultOptions = {
        realDateElement: null,
        monthdisplay: MonthDisplay.Number,
        dateFormat: 'MM/dd/yyyy',
        dayPlaceholder: 'Day',
        monthPlaceholder: 'Month',
        yearPlaceholder: 'Year'
    };

    function getMaxDay(month, year) {
        var missMonths = ['4', '6', '9', '11'];

        if ($.inArray(month, missMonths) > -1) {
            return 30;
        } else if (month == '2') {
            if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) {
                return 29;
            } else {
                return 28;
            }
        } else {
            return 31;
        }
    }


    function initNumericSelector($selector, placeHolder, min, max, displayVals) {
        $selector.find('option').remove();
        $selector.append('<option value="0">' + placeHolder + '</option>');
        var index = 0;
        for (var i = min; i <= max; i++) {            
            if (displayVals && displayVals.length == (max + 1 - min))
                $selector.append('<option value="' + i + '">' + displayVals[index] + '</option>');
            else
                $selector.append('<option value="' + i + '">' + i + '</option>');
            index++;
        }
    }

    $.fn.initDateSelectors = function (options) {
        options = $.extend(true, {}, defaultOptions, options);

        var daySelector = $(this).find("select[select-type='day']");
        var monthSelector = $(this).find("select[select-type='month']");
        var yearSelector = $(this).find("select[select-type='year']");

        if (daySelector == null || monthSelector == null || yearSelector == null)
            return;

        var currentDate = new Date();

        if(options.monthdisplay == MonthDisplay.FullName)
            initNumericSelector(monthSelector, options.monthPlaceholder, 1, 12, monthNames);
        else if (options.monthdisplay == MonthDisplay.ShortName)
            initNumericSelector(monthSelector, options.monthPlaceholder, 1, 12, monthShortNames);
        else
            initNumericSelector(monthSelector, options.monthPlaceholder, 1, 12);

        initNumericSelector(yearSelector, options.yearPlaceholder, 1970, currentDate.getFullYear() - 1);

        if (options.realDateElement != null) {
            var inputDateString = options.realDateElement.val();
            var inputDate = DateLib.getDateFromFormat(inputDateString, options.dateFormat);
            if (inputDate != null) {
                var maxDay = getMaxDay(inputDate.getFullMonth(), inputDate.getFullYear());
                initNumericSelector(daySelector, options.dayPlaceholder, 1, maxDay);
                daySelector.val(inputDate.getDate());
                monthSelector.val(inputDate.getFullMonth());
                yearSelector.val(inputDate.getFullYear());
            } else {
                initNumericSelector(daySelector, options.dayPlaceholder, 1, 31);
                daySelector.val('0');
                monthSelector.val('0');
                yearSelector.val('0');
            }
        }


        function resetRealDateElement() {
            var selectedYear = yearSelector.val();
            var selectedMonth = monthSelector.val();
            var selectedDay = daySelector.val();
            if (selectedMonth == 0 || selectedYear == 0 || selectedDay == 0) {
                options.realDateElement.val("");
                return;
            }

            var selectedDate = new Date(selectedYear, selectedMonth - 1, selectedDay);
            var dateString = DateLib.dateFormat(selectedDate, options.dateFormat);
            options.realDateElement.val(dateString);
        };

        function rebuildDayOption() {
            var selectedYear = yearSelector.val();
            var selectedMonth = monthSelector.val();
            var selectedDay = daySelector.val();
            if (selectedMonth == 0 || selectedYear == 0) {
                options.realDateElement.val("");
                return;
            }
            var maxDay = getMaxDay(selectedMonth, selectedYear);
            // Rebuild day selector
            initNumericSelector(daySelector, options.dayPlaceholder, 1, maxDay);

            if (selectedDay > maxDay)
                selectedDay = 1;

            // Reset day select option
            daySelector.val('' + selectedDay + '');

            // Reset value for hidden date input
            resetRealDateElement();
        };

        // Register option changed events
        yearSelector.on('change', rebuildDayOption);
        monthSelector.on('change', rebuildDayOption);
        daySelector.on('change', resetRealDateElement);        
    }
})(window);