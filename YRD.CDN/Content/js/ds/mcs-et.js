/*会员卡数据统计-充值统计-充值走势*/
$(function(){
    Highcharts.chart('mcs-et', {
        chart: {
            zoomType: 'xy'
        },
        title: {
            text: '快速消费统计报表'
        },
        credits:{
            enabled:false
        },
        xAxis: [{
            categories: ['2', '4', '6', '8', '10', '12',
                '14', '16', '18', '20', '22', '24','26','28','30'],
            crosshair: true
        }],
        yAxis: [{ // Primary yAxis
            labels: {
                format: '{value}元',
                style: {
                    color: Highcharts.getOptions().colors[0]
                }
            },
            title: {
                text: '快速消费金额',
                style: {
                    color: Highcharts.getOptions().colors[0]
                }
            }
        }, { // Secondary yAxis
            title: {
                text: '快速消费次数',
                style: {
                    color: Highcharts.getOptions().colors[1]
                }
            },
            labels: {
                format: '{value}个',
                style: {
                    color: Highcharts.getOptions().colors[1]
                }
            },
            opposite: true
        }],
        tooltip: {
            shared: true
        },
        legend: {
            layout: 'vertical',
            align: 'left',
            x: 120,
            verticalAlign: 'top',
            y: 100,
            floating: true,
            backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'
        },
        series: [{
            name: '快速消费金额',
            type: 'column',
            data: [49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4,60.10,72.34,70.88],
            tooltip: {
                valueSuffix: '元'
            }
        },{
            name: '快速消费次数',
            type: 'spline',
            yAxis: 1,
            data: [-2.0, 3.9, 3.5, 4.5, 5.2, 6.5, 5.2, 6.5, 3.3, 1.3, 2.9, 3.6,1.1,2.0,0.9],
            tooltip: {
                valueSuffix: '个'
            }
        }]
    });
});