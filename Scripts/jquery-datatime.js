jQuery(function ($) {
    $.validator.addMethod('date',
    function (value, element) {
        if (this.optional(element)) {
            return true;
        }

        console.log("script work");
        var ok = true;
        //try {
        //    $.datepicker.parseDate('dd.mm.yy', value);
        //}
        //catch (err) {
        //    ok = false;
        //}
        return ok;
    });
});