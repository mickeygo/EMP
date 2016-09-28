// JavaScript startup, it will  automatically loaded When the page is initialized automatically loaded.

$(function () {
    var msie = navigator.userAgent.match(/msie/i);
    $.browser = {};
    $.browser.msie = {};

    // responsive menu
    $('.navbar-toggle').click(function (e) {
        e.preventDefault();
        $('.nav-sm').html($('.navbar-collapse').html());
        $('.sidebar-nav').toggleClass('active');
        $(this).toggleClass('active');
    });

    var $sidebarNav = $('.sidebar-nav');
    // Hide responsive navbar on clicking outside
    $(document).mouseup(function (e) {
        if (!$sidebarNav.is(e.target) // if the target of the click isn't the container...
            && $sidebarNav.has(e.target).length === 0
            && !$('.navbar-toggle').is(e.target)
            && $('.navbar-toggle').has(e.target).length === 0
            && $sidebarNav.hasClass('active')
            )// ... nor a descendant of the container
        {
            e.stopPropagation();
            $('.navbar-toggle').click();
        }
    });

    //highlight current / active link
    $('ul.main-menu li a').each(function () {
        if (this.href == String(window.location))
            $(this).parent().addClass('active');
    });

    //ajaxify menus
    $('a.ajax-link').click(function (e) {
        if (msie) e.which = 1;
        if (e.which != 1 || !$('#is-ajax').prop('checked') || $(this).parent().hasClass('active')) return;
        e.preventDefault();
        $('.sidebar-nav').removeClass('active');
        $('.navbar-toggle').removeClass('active');
        $('#loading').remove();
        //$('#content').fadeOut().parent().append('<div id="loading" class="center">Loading...<div class="center"></div></div>');
        $('body').append('<div id="loading" class="center">Loading...<div class="center"></div></div>');
        var $clink = $(this);
        History.pushState(null, null, $clink.attr('href'));
        $('ul.main-menu li.active').removeClass('active');
        $clink.parent('li').addClass('active');
    });

    // menu accordion
    $('.accordion > a').click(function (e) {
        e.preventDefault();
        var $ul = $(this).siblings('ul');
        var $li = $(this).parent();
        if ($ul.is(':visible')) $li.removeClass('active');
        else $li.addClass('active');
        $ul.slideToggle();
    });

    $('.accordion li.active:first').parents('ul').slideDown();

    // datatable
    $('.datatable').dataTable({
        dom: "<'row'<'col-md-6'l><'col-md-6'f>r>t<'row'<'col-md-12'i><'col-md-12 center-block'p>>",
        paginationType: "bootstrap",
        language: {
            "sProcessing":   "处理中...",
            "sLengthMenu":   "显示 _MENU_ 项结果",
            "sZeroRecords":  "没有匹配结果",
            "sInfo":         "显示第 _START_ 至 _END_ 项结果，共 _TOTAL_ 项",
            "sInfoEmpty":    "显示第 0 至 0 项结果，共 0 项",
            "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
            "sInfoPostFix":  "",
            "sSearch":       "搜索:",
            "sUrl":          "",
            "sEmptyTable":     "表中数据为空",
            "sLoadingRecords": "载入中...",
            "sInfoThousands":  ",",
            "oPaginate": {
                "sFirst":    "首页",
                "sPrevious": "上页",
                "sNext":     "下页",
                "sLast":     "末页"
            },
            "oAria": {
                "sSortAscending":  ": 以升序排列此列",
                "sSortDescending": ": 以降序排列此列"
            }
        },
        info: $('.datatable').hasClass('datatable-paging'),
        processing: true,
        searching: false,
        ordering: false,
        sort: false,
        destroy: true,
        scrollCollapse: true,
        //scrollX: true,
        lengthChange: false,
        paging: $('.datatable').hasClass('datatable-paging'),
        pageLength: 20,
        paginationType: "full_numbers"
    });
    
    // box
    $('.btn-close').append('<i class="glyphicon glyphicon-remove"></i>');
    $('.btn-close').click(function (e) {
        e.preventDefault();
        $(this).closest('.box-inner').fadeOut();
    });
    $('.btn-minimize').append('<i class="glyphicon glyphicon-chevron-up"></i>');
    $('.btn-minimize').click(function (e) {
        e.preventDefault();
        var $target = $(this).closest('.box-inner').find('.box-content')
        if ($target.is(':visible'))
            $('i', $(this)).removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');
        else
            $('i', $(this)).removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');
        $target.slideToggle();
    });
    $('.btn-setting').append('<i class="glyphicon glyphicon-cog"></i>');
    $('.btn-setting').click(function (e) {
        e.preventDefault();
        // use dialog to open a window.
    });

    //
    doReady();
});

function doReady() {
    // Bootstrap tooltip
    $('[data-toggle="tooltip"]').tooltip();

    // Bootstrap popover
    $('[data-toggle="popover"]').popover();

    // prevent # links from moving to top
    $('a[href="#"][data-top!=true]').click(function (e) {
        e.preventDefault();
    });

    // notifications
    // type: alert/success/error/warning/information
    // layout: top/[topLeft/topCenter/topRight]/[center/centerLeft/centerRight]/[bottomLeft/bottomCenter/bottomRight]/bottom
    $(document).on("click", ".noty", function (e) {
        //e.preventDefault();

        var options = JSON.parse($(this).attr('data-noty-options') || '{}');
        options["text"] = options["text"] || $(this).attr('data-noty-text') || "";
        options["type"] = options["type"] || $(this).attr('data-noty-type') || "information";
        options["layout"] = options["layout"] || $(this).attr('data-noty-layout') || "top";
        options["modal"] = options["modal"] || $(this).attr('data-noty-modal') || false;  // 遮罩 true/false
        options["dismissQueue"] = true;  // add to queue
        options["maxVisible"] = 10; // 一个队列中同一时间最多显示的数量
        options["timeout"] = options["timeout"] || $(this).attr('data-noty-timeout') || false;  // auto close

        noty(options);
    });

    // datepicker
    $(document).on("focusin", "input[data-format=date]", function (e) {
        $(this).datepicker({
            changeMonth: true,
            changeYear: true
        });
    });

    // jQuery validate
    $("form").validate();
    jQuery.validator.addMethod("specific", function (value, element) {
        return this.optional(element) || /^[a-zA-Z0-9_]*$/.test(value);
    }, "请输入字母数字或下划线");
    jQuery.validator.addMethod("chinese", function (value, element) {
        return this.optional(element) || /^[\u4e00-\u9fa5]*$/.test(value);
    }, "只能为汉字");
}


// additional functions for data table
$.fn.dataTableExt.oApi.fnPagingInfo = function (oSettings) {
    return {
        "iStart": oSettings._iDisplayStart,
        "iEnd": oSettings.fnDisplayEnd(),
        "iLength": oSettings._iDisplayLength,
        "iTotal": oSettings.fnRecordsTotal(),
        "iFilteredTotal": oSettings.fnRecordsDisplay(),
        "iPage": Math.ceil(oSettings._iDisplayStart / oSettings._iDisplayLength),
        "iTotalPages": Math.ceil(oSettings.fnRecordsDisplay() / oSettings._iDisplayLength)
    };
}

$.extend($.fn.dataTableExt.oPagination, {
    "bootstrap": {
        "fnInit": function (oSettings, nPaging, fnDraw) {
            var oLang = oSettings.oLanguage.oPaginate;
            var fnClickHandler = function (e) {
                e.preventDefault();
                if (oSettings.oApi._fnPageChange(oSettings, e.data.action)) {
                    fnDraw(oSettings);
                }
            };

            $(nPaging).addClass('pagination').append(
                '<ul class="pagination">' +
                    '<li class="prev disabled"><a href="#">&larr; ' + oLang.sPrevious + '</a></li>' +
                    '<li class="next disabled"><a href="#">' + oLang.sNext + ' &rarr; </a></li>' +
                    '</ul>'
            );
            var els = $('a', nPaging);
            $(els[0]).bind('click.DT', { action: "previous" }, fnClickHandler);
            $(els[1]).bind('click.DT', { action: "next" }, fnClickHandler);
        },

        "fnUpdate": function (oSettings, fnDraw) {
            var iListLength = 5;
            var oPaging = oSettings.oInstance.fnPagingInfo();
            var an = oSettings.aanFeatures.p;
            var i, j, sClass, iStart, iEnd, iHalf = Math.floor(iListLength / 2);

            if (oPaging.iTotalPages < iListLength) {
                iStart = 1;
                iEnd = oPaging.iTotalPages;
            }
            else if (oPaging.iPage <= iHalf) {
                iStart = 1;
                iEnd = iListLength;
            } else if (oPaging.iPage >= (oPaging.iTotalPages - iHalf)) {
                iStart = oPaging.iTotalPages - iListLength + 1;
                iEnd = oPaging.iTotalPages;
            } else {
                iStart = oPaging.iPage - iHalf + 1;
                iEnd = iStart + iListLength - 1;
            }

            for (i = 0, iLen = an.length; i < iLen; i++) {
                // remove the middle elements
                $('li:gt(0)', an[i]).filter(':not(:last)').remove();

                // add the new list items and their event handlers
                for (j = iStart; j <= iEnd; j++) {
                    sClass = (j == oPaging.iPage + 1) ? 'class="active"' : '';
                    $('<li ' + sClass + '><a href="#">' + j + '</a></li>')
                        .insertBefore($('li:last', an[i])[0])
                        .bind('click', function (e) {
                            e.preventDefault();
                            oSettings._iDisplayStart = (parseInt($('a', this).text(), 10) - 1) * oPaging.iLength;
                            fnDraw(oSettings);
                        });
                }

                // add / remove disabled classes from the static elements
                if (oPaging.iPage === 0) {
                    $('li:first', an[i]).addClass('disabled');
                } else {
                    $('li:first', an[i]).removeClass('disabled');
                }

                if (oPaging.iPage === oPaging.iTotalPages - 1 || oPaging.iTotalPages === 0) {
                    $('li:last', an[i]).addClass('disabled');
                } else {
                    $('li:last', an[i]).removeClass('disabled');
                }
            }
        }
    }
});