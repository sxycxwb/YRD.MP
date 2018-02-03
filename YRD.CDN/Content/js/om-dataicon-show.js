/*
 * 营业收入-数据图标显示
 * */
$(function () {
    $('#oi-dataicon').highcharts({
        title: {
            text: '',
            x: -20 //center
        },
        subtitle: {
            text: '',
            x: -20
        },
        xAxis: {
            categories: ['2', '4', '6', '8', '10', '12',
                '14', '16', '18', '20', '22', '24','26','28','30']
        },
        yAxis: {
            title: {
                text: '收入(千)'
            },
            plotLines: [{
                value: 0,
                width: 1,
                color: '#808080'
            }]
        },
        credits:{
            enabled:false
        },
        tooltip: {
            valueSuffix: '°C'
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        series: [{
            name: '总收入',
            data: [7.0, 6.9, 9.5, 14.5, 18.2, 21.5, 25.2, 26.5, 23.3, 18.3, 13.9, 9.6,8.8,7.6,4.5]
        }, {
            name: '现金',
            data: [0.2, 0.8, 5.7, 11.3, 17.0, 22.0, 24.8, 24.1, 20.1, 14.1, 8.6, 2.5,2.0,1.9,1.5]
        }, {
            name: '刷卡',
            data: [7.0, 6.1, 4.0, 3.2, 3.2, 2.5, 4.8, 5.2, 3.2, 4.5, 5.3, 5.3,7.1,6.4,6.3]
        }]
    });
});
