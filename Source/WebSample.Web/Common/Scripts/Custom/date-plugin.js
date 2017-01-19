(function (window) {
    'use strict';

    function initLib() {
        var dateLib = {};
        /*
        * [Rebuild]
        * (c) 2007-2009 Steven Levithan <stevenlevithan.com>
        * MIT license
        *
        * Includes enhancements by Scott Trenda <scott.trenda.net>
        * and Kris Kowal <cixar.com/~kris.kowal/>
        *
        * Accepts a date, a mask, or a date and a mask.
        * Returns a formatted version of the given date.
        * The date defaults to the current date/time.
        * The mask defaults to dateFormat.masks.default.
        */
        dateLib.dateFormat = function () {
            var token = /d{1,4}|m{1,4}|yy(?:yy)?|([HhMsTt])\1?|[LloSZ]|"[^"]*"|'[^']*'/g,
                timezone = /\b(?:[PMCEA][SDP]T|(?:Pacific|Mountain|Central|Eastern|Atlantic) (?:Standard|Daylight|Prevailing) Time|(?:GMT|UTC)(?:[-+]\d{4})?)\b/g,
                timezoneClip = /[^-+\dA-Z]/g,
                pad = function (val, len) {
                    val = String(val);
                    len = len || 2;
                    while (val.length < len) val = "0" + val;
                    return val;
                };

            // Regexes and supporting functions are cached through closure
            return function (date, mask, utc) {
                var dF = this.dateFormat;

                // You can't provide utc if you skip other args (use the "UTC:" mask prefix)
                if (arguments.length == 1 && Object.prototype.toString.call(date) == "[object String]" && !/\d/.test(date)) {
                    mask = date;
                    date = undefined;
                }

                // Passing date through Date applies Date.parse, if necessary
                date = date ? new Date(date) : new Date;
                if (isNaN(date)) throw SyntaxError("invalid date");

                mask = String(dF.masks[mask] || mask || dF.masks["default"]);
                mask = mask.toLowerCase();
                // Allow setting the utc argument via the mask
                if (mask.slice(0, 4) == "UTC:") {
                    mask = mask.slice(4);
                    utc = true;
                }

                var _ = utc ? "getUTC" : "get",
                    d = date[_ + "Date"](),
                    D = date[_ + "Day"](),
                    m = date[_ + "Month"](),
                    y = date[_ + "FullYear"](),
                    H = date[_ + "Hours"](),
                    M = date[_ + "Minutes"](),
                    s = date[_ + "Seconds"](),
                    L = date[_ + "Milliseconds"](),
                    o = utc ? 0 : date.getTimezoneOffset(),
                    flags = {
                        d: d,
                        dd: pad(d),
                        ddd: dF.naming.dayNames[D],
                        dddd: dF.naming.dayNames[D + 7],
                        m: m + 1,
                        mm: pad(m + 1),
                        mmm: dF.naming.monthNames[m],
                        mmmm: dF.naming.monthNames[m + 12],
                        yy: String(y).slice(2),
                        yyyy: y,
                        h: H % 12 || 12,
                        hh: pad(H % 12 || 12),
                        H: H,
                        HH: pad(H),
                        M: M,
                        MM: pad(M),
                        s: s,
                        ss: pad(s),
                        l: pad(L, 3),
                        L: pad(L > 99 ? Math.round(L / 10) : L),
                        t: H < 12 ? "a" : "p",
                        tt: H < 12 ? "am" : "pm",
                        T: H < 12 ? "A" : "P",
                        TT: H < 12 ? "AM" : "PM",
                        Z: utc ? "UTC" : (String(date).match(timezone) || [""]).pop().replace(timezoneClip, ""),
                        o: (o > 0 ? "-" : "+") + pad(Math.floor(Math.abs(o) / 60) * 100 + Math.abs(o) % 60, 4),
                        S: ["th", "st", "nd", "rd"][d % 10 > 3 ? 0 : (d % 100 - d % 10 != 10) * d % 10]
                    };

                return mask.replace(token, function ($0) {
                    return $0 in flags ? flags[$0] : $0.slice(1, $0.length - 1);
                });
            };
        }();

        // Some common format strings
        dateLib.dateFormat.masks = {
            "default": "ddd mmm dd yyyy HH:MM:ss",
            shortDate: "m/d/yy",
            mediumDate: "mmm d, yyyy",
            longDate: "mmmm d, yyyy",
            fullDate: "dddd, mmmm d, yyyy",
            shortTime: "h:MM TT",
            mediumTime: "h:MM:ss TT",
            longTime: "h:MM:ss TT Z",
            isoDate: "yyyy-mm-dd",
            isoTime: "HH:MM:ss",
            isoDateTime: "yyyy-mm-dd'T'HH:MM:ss",
            isoUtcDateTime: "UTC:yyyy-mm-dd'T'HH:MM:ss'Z'"
        };

        // Internationalization strings
        dateLib.dateFormat.naming = {
            dayNames: [
                "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat",
                "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
            ],
            monthNames: [
                "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec",
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"
            ]
        };


        //--------------------------------------------------------------
        // ===================================================================
        // [Rebuild]
        // Author: Matt Kruse <matt@mattkruse.com>
        // WWW: http://www.mattkruse.com/
        // =================================================================== 

        // ------------------------------------------------------------------
        // Utility functions for parsing in getDateFromFormat()
        // ------------------------------------------------------------------
        function isInteger(val) {
            var digits = "1234567890";
            for (var i = 0; i < val.length; i++) {
                if (digits.indexOf(val.charAt(i)) == -1) { return false; }
            }
            return true;
        }
        function getInt(str, i, minlength, maxlength) {
            for (var x = maxlength; x >= minlength; x--) {
                var token = str.substring(i, i + x);
                if (token.length < minlength) { return null; }
                if (isInteger(token)) { return token; }
            }
            return null;
        }

        // ------------------------------------------------------------------
        // getDateFromFormat( date_string , format_string )
        //
        // This function takes a date string and a format string. It matches
        // If the date string matches the format string, it returns the date.
        // ------------------------------------------------------------------
        dateLib.getDateFromFormat = function(val, format) {
            val = val + "";
            format = format + "";
            var iVal = 0;
            var iFormat = 0;
            var c = "";
            var token = "";
            var x, y;
            var now = new Date();
            var year = now.getYear();
            var month = now.getMonth() + 1;
            var date = 1;
            var hh = now.getHours();
            var mm = now.getMinutes();
            var ss = now.getSeconds();
            var ampm = "";

            while (iFormat < format.length) {
                // Get next token from format string
                c = format.charAt(iFormat);
                token = "";
                while ((format.charAt(iFormat) == c) && (iFormat < format.length)) {
                    token += format.charAt(iFormat++);
                }
                // Extract contents of value based on format token
                if (token == "yyyy" || token == "yy" || token == "y") {
                    if (token == "yyyy") { x = 4; y = 4; }
                    if (token == "yy") { x = 2; y = 2; }
                    if (token == "y") { x = 2; y = 4; }
                    year = getInt(val, iVal, x, y);
                    if (year == null) { return null; }
                    iVal += year.length;
                    if (year.length == 2) {
                        if (year > 70) { year = 1900 + (year - 0); }
                        else { year = 2000 + (year - 0); }
                    }
                }
                else if (token == "MMM" || token == "NNN") {
                    month = 0;
                    for (var i = 0; i < naming.monthNames.length; i++) {
                        var monthName = naming.monthNames[i];
                        if (val.substring(iVal, iVal + monthName.length).toLowerCase() == monthName.toLowerCase()) {
                            if (token == "MMM" || (token == "NNN" && i > 11)) {
                                month = i + 1;
                                if (month > 12) { month -= 12; }
                                iVal += monthName.length;
                                break;
                            }
                        }
                    }
                    if ((month < 1) || (month > 12)) { return null; }
                }
                else if (token == "EE" || token == "E") {
                    for (var i = 0; i < naming.dayNames.length; i++) {
                        var dayName = naming.dayNames[i];
                        if (val.substring(iVal, iVal + dayName.length).toLowerCase() == dayName.toLowerCase()) {
                            iVal += dayName.length;
                            break;
                        }
                    }
                }
                else if (token == "MM" || token == "M") {
                    month = getInt(val, iVal, token.length, 2);
                    if (month == null || (month < 1) || (month > 12)) { return null; }
                    iVal += month.length;
                }
                else if (token == "dd" || token == "d") {
                    date = getInt(val, iVal, token.length, 2);
                    if (date == null || (date < 1) || (date > 31)) { return null; }
                    iVal += date.length;
                }
                else if (token == "hh" || token == "h") {
                    hh = getInt(val, iVal, token.length, 2);
                    if (hh == null || (hh < 1) || (hh > 12)) { return null; }
                    iVal += hh.length;
                }
                else if (token == "HH" || token == "H") {
                    hh = getInt(val, iVal, token.length, 2);
                    if (hh == null || (hh < 0) || (hh > 23)) { return null; }
                    iVal += hh.length;
                }
                else if (token == "KK" || token == "K") {
                    hh = getInt(val, iVal, token.length, 2);
                    if (hh == null || (hh < 0) || (hh > 11)) { return null; }
                    iVal += hh.length;
                }
                else if (token == "kk" || token == "k") {
                    hh = getInt(val, iVal, token.length, 2);
                    if (hh == null || (hh < 1) || (hh > 24)) { return null; }
                    iVal += hh.length; hh--;
                }
                else if (token == "mm" || token == "m") {
                    mm = getInt(val, iVal, token.length, 2);
                    if (mm == null || (mm < 0) || (mm > 59)) { return null; }
                    iVal += mm.length;
                }
                else if (token == "ss" || token == "s") {
                    ss = getInt(val, iVal, token.length, 2);
                    if (ss == null || (ss < 0) || (ss > 59)) { return null; }
                    iVal += ss.length;
                }
                else if (token == "a") {
                    if (val.substring(iVal, iVal + 2).toLowerCase() == "am") { ampm = "AM"; }
                    else if (val.substring(iVal, iVal + 2).toLowerCase() == "pm") { ampm = "PM"; }
                    else { return null; }
                    iVal += 2;
                }
                else {
                    if (val.substring(iVal, iVal + token.length) != token) { return null; }
                    else { iVal += token.length; }
                }
            }
            // If there are any trailing characters left in the value, it doesn't match
            if (iVal != val.length) { return null; }
            // Is date valid for month?
            if (month == 2) {
                // Check for leap year
                if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) { // leap year
                    if (date > 29) { return null; }
                }
                else { if (date > 28) { return null; } }
            }
            if ((month == 4) || (month == 6) || (month == 9) || (month == 11)) {
                if (date > 30) { return null; }
            }
            // Correct hours value
            if (hh < 12 && ampm == "PM") { hh = hh - 0 + 12; }
            else if (hh > 11 && ampm == "AM") { hh -= 12; }
            var newdate = new Date(year, month - 1, date, hh, mm, ss);

            return newdate;
        }
        
        return dateLib;
    }

    // Define globally if it doesn't already exist
    if (typeof (DateLib) === 'undefined') {
        window.DateLib = initLib();
    }
    else {
        console.log("DateLib library already defined.");
    }
})(window);

Date.prototype.getFullMonth = function () {
    return this.getMonth() + 1;
};
