// JavaScript startup, it will  automatically loaded When the page is initialized automatically loaded.

var Startup = function () {

    var handleDatePickers = function () {

        if (jQuery().datepicker) {
            $('.date-picker').datepicker({
                rtl: App.isRTL(),
                orientation: "left",
                autoclose: true
            });
            //$('body').removeClass("modal-open"); // fix bug when inline picker is used in modal
        }

        /* Workaround to restrict daterange past date select: http://stackoverflow.com/questions/11933173/how-to-restrict-the-selectable-date-ranges-in-bootstrap-datepicker */
    }

    var handleTimePickers = function () {

        if (jQuery().timepicker) {
            $('.timepicker-default').timepicker({
                autoclose: true,
                showSeconds: true,
                minuteStep: 1
            });

            $('.timepicker-no-seconds').timepicker({
                autoclose: true,
                minuteStep: 5
            });

            $('.timepicker-24').timepicker({
                autoclose: true,
                minuteStep: 5,
                showSeconds: false,
                showMeridian: false
            });

            // handle input group button click
            $('.timepicker').parent('.input-group').on('click', '.input-group-btn', function (e) {
                e.preventDefault();
                $(this).parent('.input-group').find('.timepicker').timepicker('showWidget');
            });
        }
    }

    // datatable
    var handleDataTables = function () {

        if (!$().dataTable) {
            return;
        }

        var options = {
            dom: "<'row'<'col-md-8 col-sm-12'pli><'col-md-4 col-sm-12'<'table-group-actions pull-right'>>r><'table-responsive't><'row'<'col-md-8 col-sm-12'pli><'col-md-4 col-sm-12'>>",
            paginationType: "bootstrap",
            info: true,
            processing: true,
            searching: false,
            ordering: false,
            sort: false,
            destroy: true,
            scrollCollapse: true,
            //scrollX: true,
            lengthChange: false,
            paging: true,
            pageLength: 20,
            paginationType: "full_numbers"
        };

        $('table.datatable').dataTable(options);
    }

    // tree
    var handleTree = function () {

        if (!$().jstree) {
            return;
        }

        $('div.tree').jstree({
            "core": {
                "themes": {
                    "responsive": false
                },
                "check_callback": true
            },
            "types": {
                "default": {
                    "icon": "fa fa-folder icon-state-warning icon-lg"
                },
                "file": {
                    "icon": "fa fa-file icon-state-warning icon-lg"
                }
            },
            "plugins": [ "types" ]
        });
    }

    // encapsulate the 'toastr' plugin.
    var handleNotice = function () {
        if (!toastr) {
            return null;
        }

        toastr.options = {
            "closeButton": true,
            "debug": false,
            "positionClass": "toast-top-center",  // toast-top-right,toast-top-full-width
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        };

        $.extend({
            notice: function () {
                return toastr;
            }()
        });
    }

    // form validation
    var handleFormValidation = function () {
        $(document).on("submit", "form", function (e) {
            $(this).validate({
                errorElement: 'span', //default input error message container
                errorClass: 'help-block', // default input error message class
                focusInvalid: false, // do not focus the last invalid input
                invalidHandler: function (event, validator) { //display error alert on form submit   
                },
                highlight: function (element) { // hightlight error inputs
                    $(element).closest('.form-group').addClass('has-error'); // set error class to the control group
                },
                success: function (label) {
                    label.closest('.form-group').removeClass('has-error');
                    label.remove();
                },
                errorPlacement: function (error, element) {
                    error.insertAfter(element.closest('.input-icon'));
                },
                submitHandler: function (form) {
                    form.submit(); // form validation success, call ajax form submit
                }
            });
        });
    }

    // inputMask
    var handleInputMask = function () {
        if ($().inputmask) {
            $(":input").inputmask();

            //$(document).on("focusin", ":input", function () {
            //    $(this).inputmask();
            //});
        }
    }

    // SignalR Hub
    var handleSignalRHub = function () {
        if (!$.connection.dotPlatformCommonHub) {
            return null;
        }
        
        $.extend({
            hub: {
                send: function (fn) {
                    // Start the connection.
                    $.connection.hub.start().done(function () {
                        fn();
                    });
                    return this;
                },
                done: function (fn) {
                    // Reference the auto-generated proxy for the hub.  
                    var hub = $.connection.dotPlatformCommonHub;
                    // Create a function that the hub can call back to handle messages.
                    hub.client.getNotification = function (data) {
                        fn(data);
                    };
                    return this;
                },
                error: function (fn) {
                    $.connection.hub.error(function (error) {
                        fn(error);
                    });
                    return this;
                }
            }
        });
    }

    return {
        //main function to initiate the module
        init: function () {
            handleDatePickers();
            handleTimePickers();
            handleDataTables();
            handleTree();
            handleNotice();
            handleFormValidation();
            handleInputMask();
            handleSignalRHub();
        }
    };
}();

$(function () {
    Startup.init();
});