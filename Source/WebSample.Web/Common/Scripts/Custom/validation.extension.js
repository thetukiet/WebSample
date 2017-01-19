// Validator for minimum aceptable age.
// Assumming input date format is MM/dd/yyyy. the same with the Culture configuration in Web.config
if (!jQuery) { throw new Error("This extension requires jQuery") }
$.validator.addMethod('min_age', function (value, element, config) {
    var today = new Date();
    var birthDate;
    var minAge = 1;

        if (config == null)
            return true;

        if (typeof config === 'object') {
            if (config.format != null)
                birthDate = DateLib.getDateFromFormat(value, config.format);
            else
                birthDate = new Date(value);

            if (config.value != null)
                minAge = config.value;
        } else {
            birthDate = new Date(value);
            minAge = config;
        }

        var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age >= minAge;
},

function (config) {
    if (config == null)
        return 'Your age is not acceptable';
    if (typeof config === 'object') {
        if (config.value != null)
            return 'The minimum acceptable age is ' + config.value;
        else
            return 'Your age is not acceptable';
    }
    return 'The minimum acceptable age is ' + config;
});
