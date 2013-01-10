/// <reference path="~/Scripts/knockout-2.1.0.js"/>
/// <reference path="~/Scripts/jquery-1.7.1.intellisense.js"/>

google.load("visualization", "1", { packages: ["corechart"] });

var NumberTranslator = {
    translate: function(number) {
        if (number === 37) {
            return '0';
        }
        if (number === 38) {
            return '00';
        }
        return number;
    }
};

$(function() {
    var $slotTypeSelect = $('#SlotType');
    var $calculateBets = $('#calculateBets');
    var $calculateDuration = $('#calculateDuration');
    var $betAmount = $('#betAmount');
    
    function GetSlotTypeName(slotTypeNumber) {
        return $slotTypeSelect.find("option[value='" + slotTypeNumber + "']").text();
    }

    var Bet = function(slotType, slotTypeText, amount) {
        this.slotType = slotType;
        this.slotTypeText = slotTypeText;
        this.amount = amount;

        this.remove = function() {
            viewModel.bets.remove(this);
        };
    };

    var IterationResult = function (investment, delta, gameResults) {
        this.gameResults = gameResults;
        this.delta = delta;
        this.investment = investment;
        this.generateDataArray = function () {
            var dataArray = [],
                runningTotal = 0;
            $.each(this.gameResults, function (index, item) {
                runningTotal += item.Delta;
                var toolTip = 'Hit Number: ' + item.HitNumber + '\n\nBets:';

                $.each(item.BetResults, function (index2, betResult) {
                    var winnerSymbol = betResult.IsWinner ? ' + ' : ' - ';
                    toolTip += '\n' + winnerSymbol + '$' + betResult.Delta + ' ' + GetSlotTypeName(betResult.Bet.SlotType);
                });

                dataArray.push([index + 1, runningTotal, toolTip]);
            });
            return dataArray;
        };
        this.showGraph = function () {
            var data = new google.visualization.DataTable();
            data.addColumn('number', 'Game'); // Implicit domain label col.
            data.addColumn('number', 'Winnings'); // Implicit series 1 data col.
            data.addColumn({ type: 'string', role: 'tooltip' });  // interval role col.
            data.addRows(this.generateDataArray());

            var options = {
                title: 'Game Results',
                height: '300',
                width: '500'
            };

            $('#chartModal').modal('show');

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        };
        this.remove = function () {
            viewModel.iterationResults.remove(this);
        };
    };

    var DurationResult = function (totalDuration, wallet, gameResults) {
        this.gameResults = gameResults;
        this.totalDuration = totalDuration;
        this.wallet = wallet;
        this.generateDataArray = function () {
            var dataArray = [],
                runningTotal = wallet;
            $.each(this.gameResults, function (index, item) {
                runningTotal += item.Delta;
                var toolTip = 'Hit Number: ' + item.HitNumber + '\n\nWallet: $' + runningTotal + '\n\nBets:';

                $.each(item.BetResults, function (index2, betResult) {
                    var winnerSymbol = betResult.IsWinner ? ' + ' : ' - ';
                    toolTip += '\n' + winnerSymbol + '$' + betResult.Delta + ' ' + GetSlotTypeName(betResult.Bet.SlotType);
                });

                dataArray.push([index + 1, runningTotal, toolTip]);
            });
            return dataArray;
        };
        this.showGraph = function () {
            var data = new google.visualization.DataTable();
            data.addColumn('number', 'Game'); // Implicit domain label col.
            data.addColumn('number', 'Winnings'); // Implicit series 1 data col.
            data.addColumn({ type: 'string', role: 'tooltip' });  // interval role col.
            data.addRows(this.generateDataArray());

            var options = {
                title: 'Game Results',
                height: '300',
                width: '500'
            };

            $('#chartModal').modal('show');

            var chart = new google.visualization.LineChart(document.getElementById('chart_div'));
            chart.draw(data, options);
        };
        this.remove = function () {
            viewModel.durationResults.remove(this);
        };
    };

    var viewModel = {
        iterations: ko.observable(10),
        wallet: ko.observable(100),
        betDuration: ko.observable('00:02:00'),
        bets: ko.observableArray(),
        iterationResults: ko.observableArray(),
        durationResults: ko.observableArray(),
        addBet: function () {
            if (parseInt($betAmount.val()) > 0) {
                viewModel.bets.push(new Bet($slotTypeSelect.val(), GetSlotTypeName($slotTypeSelect.val()), $betAmount.val()));
            }
        },
        calculateBets: function () {
            var data = ko.toJSON({
                iterations: viewModel.iterations,
                bets: viewModel.bets
            });
            $.ajax({
                url: $calculateBets.data('target'),
                type: 'POST',
                contentType: 'application/json',
                dataType: 'json',
                data: data,
                success: function (returnedData) {
                    viewModel.iterationResults.push(new IterationResult(returnedData.investment, returnedData.delta, returnedData.gameResults));
                }
            }
            );
        },
        calculateDuration: function () {
            var data = ko.toJSON({
                wallet: viewModel.wallet,
                betDuration: viewModel.betDuration,
                bets: viewModel.bets
            });
            $.ajax({
                url: $calculateDuration.data('target'),
                type: 'POST',
                contentType: 'application/json',
                dataType: 'json',
                data: data,
                success: function (returnedData) {
                    viewModel.durationResults.push(new DurationResult(returnedData.totalDuration, returnedData.wallet, returnedData.gameResults));
                }
            }
            );
        }
    };

    ko.applyBindings(viewModel);
});
