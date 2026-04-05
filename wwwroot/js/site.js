// site.js – Group5Flight
// Initialize Bootstrap DateRangePicker in single-date mode
// Targets any input with class "date-picker-input"

$(function () {
    $('.date-picker-input').daterangepicker({
        singleDatePicker: true,
        showDropdowns: true,
        autoApply: true,
        minDate: moment(),
        startDate: moment().add(1, 'days'),     // default to tomorrow
        locale: {
            format: 'MM/DD/YYYY'
        }
    });
});
