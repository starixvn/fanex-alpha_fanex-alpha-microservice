(function () {
    'use strict';
    var $cbxPageSize = null;
    var $positionTakingData = null;
    var $hiddenDownline = null;
    var $hiddenCustomerId = null;

    function getPositionTaking(page, customerId, downline) {
        var criteria = {
            customerId: customerId || $hiddenCustomerId.val(),
            downline: downline || $hiddenDownline.val(),
            PageIndex: page || 1,
            PageSize: $cbxPageSize.val()
        };

        $.ajax({
            type: 'GET',
            url: window.rootUrl + 'GoldDeluxePositionTaking/GetPositionTaking?' + $.param(criteria),
            responseType: 'html',
            beforeSend: function (jqXHR, settings) { },
            success: function (data, textStatus, jqXHR) {
                $positionTakingData.html(data);

                bindPageChanging();
                bindViewDownline();
                bindPaginationEvents();
            },
            complete: function (jqXHR, textStatus) { }
        });
    }

    function bindPageChanging() {
        $cbxPageSize = $('#cbxPageSize');
        $cbxPageSize.unbind('change').bind('change', function () {
            getPositionTaking();
        });
    }

    function bindViewDownline() {
        $('.viewDownline').unbind('click').bind('click', function () {
            var $this = $(this);
            var custid = $this.data('custid');
            var downline = $this.data('downline');
            if (downline.length === 0) {
                if (ageWnd) {
                    var fromData = {
                        uplineId: loginId,
                        uplineLevel: roleId,
                        actorId: loginId,
                        custId: custid,
                        level: 1,
                        formType: 1,
                        subAccId: subAccId,
                        language: langKey
                    };

                    var url = window.rootUrl + 'GoldDeluxeSetting/GoldDeluxe/EditSetting?' + $.param(fromData);
                    ageWnd.open(url, '', 50, 10, 840, 450);
                }
            }
            else {
                getPositionTaking(1, custid, downline);

                $hiddenCustomerId.val(custid);
                $hiddenDownline.val(downline);
            }
        });
    }

    function bindPaginationEvents() {
        $('.icon').unbind('click').bind('click', function () {
            var page = $(this).data('page');
            getPositionTaking(page);
        });

        $('.pagingCurrent').unbind('keyup').bind('keyup', function (event) {
            var keyCode = event.which || event.keyCode;
            if (keyCode !== 13) {
                return;
            }

            var page = parseInt($(this).val());
            var totalPage = parseInt($('.totalPage').html());
            if (page > totalPage) {
                page = totalPage;
            }

            getPositionTaking(page);
        });
    }

    function initialize() {
        $positionTakingData = $('#positionTakingData');
        $hiddenDownline = $('#hiddenDownline');
        $hiddenCustomerId = $('#hiddenCustomerId');

        bindPageChanging();
        bindViewDownline();
        bindPaginationEvents();
    }

    initialize();
})();