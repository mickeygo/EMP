// JavaScript 启动项, 在页面初始化时会自动加载

$(function () {
    var msie = navigator.userAgent.match(/msie/i);
    $.browser = {};
    $.browser.msie = {};

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

    doReady();
});

function doReady() {
    // prevent # links from moving to top
    $('a[href="#"][data-top!=true]').click(function (e) {
        e.preventDefault();
    });

    // notifications
    $('.noty').click(function (e) {
        e.preventDefault();
        var options = $.parseJSON($(this).attr('data-noty-options'));
        noty(options);
    });

    // tooltip
    $('[data-toggle="tooltip"]').tooltip();

    // popover
    $('[data-toggle="popover"]').popover();
}