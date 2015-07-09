/* jshint unused: vars */
/* global goldDeluxeResource */
(function ($) {
    'use strict';
    var $tableCommission = null;

    function renderAgentList(agentList) {
        var html = [];
        if (agentList[0].Id !== 0) {
            html.push('<option value="0">');
            html.push(goldDeluxeResource.allAgent);
            html.push('</option>');
        }

        var agent;
        for (var i = 0, max = agentList.length; i < max; i++) {
            agent = agentList[i];
            html.push('<option value="' + agent.Id + '">');
            html.push(agent.Name);
            html.push('</option>');
        }

        $('#AgentList').html(html.join(''));
    }

    function renderGoldDeluxeCommission(commissions) {
        var html = [];
        var dataLength = commissions ? commissions.length : 0;
        if (dataLength === 0) {
            html.push('<tr class="bg_white"><td colspan="9">');
            html.push(goldDeluxeResource.noInfo);
            html.push('</td></tr>');
        }
        else {
            var number, comm, rowClass;
            for (var i = 0; i < dataLength; i++) {
                number = i + 1;
                comm = commissions[i];
                if (!comm.Enabled) {
                    rowClass = 'disabled-row';
                }
                else if (comm.Closed) {
                    rowClass = 'closed-row';
                }
                else if (comm.Suspended) {
                    rowClass = 'suspended-row';
                }
                else {
                    rowClass = number % 2 === 0 ? 'even-row' : 'odd-row';
                }
                html.push('<tr class="' + rowClass + '">');
                html.push('<td class="w-order">' + number + '</td>');
                html.push('<td class="l">' + comm.Username + '</td>');
                html.push('<td class="l">' + comm.Firstname + '</td>');
                html.push('<td class="l">' + comm.Lastname + '</td>');
                html.push('<td class="columnComm">' + comm.AgentDiscountWithFormat + '</td>');
                html.push('<td class="columnComm">' + comm.DiscountWithFormat + '</td>');
                html.push('<td class="columnComm">' + comm.PlayerDiscountWithFormat + '</td>');
                html.push('<td class="r">' + comm.CreditWithFormat + '</td>');
                html.push('<td class="l">' + comm.Username + '</td>');
                html.push('</tr>');
            }
        }

        $tableCommission.html(html.join(''));
    }

    function getCommission(formData) {
        $.ajax({
            type: 'GET',
            url: window.rootUrl + 'MemberInformation/Commission/GoldDeluxeCommission?' + $.param(formData),
            responseType: 'json',
            beforeSend: function (jqXHR, settings) {
                age.Lock(true);
            },
            success: function (data, textStatus, jqXHR) {
                if (formData.masterId && data.AgentList) {
                    renderAgentList(data.AgentList);
                }

                renderGoldDeluxeCommission(data.Commissions);
            },
            complete: function (jqXHR, textStatus) {
                age.UnLock();
            }
        });
    }

    function initialize() {
        $tableCommission = $('#tblMain tbody');

        $('#AgentList').change(function () {
            var agentId = $(this).val();
            var formData = { agentId: agentId };
            if (agentId === '0') {
                formData.masterId = $('#MasterList').val();
            }

            getCommission(formData);
        });

        $('#MasterList').change(function () {
            var masterId = $(this).val();
            getCommission({ masterId: masterId });
        });

        $('#iconBettypesRef').click(function () {
            var popH = 70, popW = 300;
            var url = window.rootUrl + '_MemberInfo/Commission/InfoCommission.aspx?isSportsbook=false';

            ageWnd.open(url, '', 320, 55, popW, popH, '', 'MemberCommissionInfoTitle', 'MemberCommissionInfoCloseButton');
        });
    }

    initialize();
})(jQuery);