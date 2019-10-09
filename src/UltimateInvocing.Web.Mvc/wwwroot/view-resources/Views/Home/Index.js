$(function () {
    //Widgets count
    $('.count-to').countTo();

    //Sales count to
    $('.sales-count-to').countTo({
        formatter: function (value, options) {
            return '$' + value.toFixed(2).replace(/(\d)(?=(\d\d\d)+(?!\d))/g, ' ').replace('.', ',');
        }
    });

    
    initDonutChart();
    initRealTimeChart();
    initSparkline();
});

var realtime = 'on';
function initRealTimeChart() {
    var data = "';"
    //Real time ==========================================================================================
    var data = [];
    var labels = [];
    abp.services.app.dashboard.getOrderGraph().done(function (content) {
        content = JSON.parse(content);
        console.log(content)
        for (var i = 0; i < content.length; i++) {
            data.push(content[i].Value);
            labels.push(content[i].Name);
        }

        var ctx = document.getElementById("myChart").getContext('2d');
        var myChart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: labels,
                datasets: [{
                    label: 'Order',
                    data: data,
                    borderColor: 'rgba(75, 192, 192, 1)',
                    backgroundColor: 'rgba(75, 192, 192, 0.2)',
                }]
            },
            options: {
                legend: {
                    display: false
                },
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true,
                            callback: function (value) { if (Number.isInteger(value)) { return value; } },
                            suggestedMax: 10,
                            stepSize: 2,
                        }
                    }]
                },
                maintainAspectRatio: false,
            }
        });
    });

    console.log(data);
    

    
    //====================================================================================================
}

function initSparkline() {
    $(".sparkline").each(function () {
        var $this = $(this);
        $this.sparkline('html', $this.data());
    });
}

function initDonutChart() {
    var bestSellers = abp.services.app.dashboard.getBestSellers().done(function (content) {
        console.log(JSON.parse(content))
        Morris.Donut({
            element: 'donut_chart',
            data: JSON.parse(content),
            colors: ['rgb(233, 30, 99)', 'rgb(0, 188, 212)', 'rgb(255, 152, 0)', 'rgb(0, 150, 136)', 'rgb(96, 125, 139)'],
            formatter: function (y) {
                return y + '%'
            }
        });
    });
}