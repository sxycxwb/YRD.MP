/*订单分类统计-销售总额占比*/
$(function () {
    $('#ocs-stp').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false
        },
        title: {
            text: ''
        },
        tooltip: {
            pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
        },
        credits:{
            enabled:false
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    format: '<b>{point.name}</b>: {point.percentage:.1f} %',
                    style: {
                        color: (Highcharts.theme && Highcharts.theme.contrastTextColor) || 'black'
                    }
                }
            }
        },
        series: [{
            type: 'pie',
            name: '使用情况',
            data: [
                ['热菜',   45.0],
                ['主食',       26.8],
                {
                    name: '套餐',
                    y: 12.8,
                    sliced: true,
                    selected: true
                },
                ['凉菜',     6.2],
                ['酒水',    8.5],
                ['饮料',   0.7]
            ]
        }]
    });
});
