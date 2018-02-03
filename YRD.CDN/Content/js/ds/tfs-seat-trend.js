/*餐桌开台统计-上座走势统计图*/
$(function () {
    $('#tfs-seat-trend').highcharts({
        title: {
            text: ''
        },
        xAxis: {
            categories: ['2', ' 4', '6', '8', '10','12','14','16',
                '18','20','22','24','26','28','30']
        },
        yAxis:{
            title:{
                text:'收入（千）'
            }
        },
        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle',
            borderWidth: 0
        },
        credits:{
            enabled:false
        },
        series: [{
            type: 'column',
            name: '上座率',
            data: [7.0, 6.9, 9.5, 14.5, 8.2, 11.5, 5.2, 6.5,3.3, 8.3,13.9, 9.6, 8.3, 13.9, 11.6]
        }, {
            type: 'column',
            name: '翻台率',
            data: [5.0, 2, 3, 3.5, 5, 10, 13, 16, 13.3, 10,9.5, 8, 8.5, 12.0, 13.6]
        }, {
            type: 'spline',
            name: '上座率',
            data: [7.0, 6.9, 9.5, 14.5, 8.2, 11.5, 5.2,6.5, 3.3,8.3,13.9, 9.6, 8.3, 13.9, 11.6],
            marker: {
                lineWidth: 2,
                lineColor: Highcharts.getOptions().colors[2],
                fillColor: 'white'
            }
        }, {
            type: 'spline',
            name: '翻台率',
            data: [5.0, 2, 3, 3.5, 5, 10, 13, 16, 13.3, 10,9.5, 8, 8.5, 12.0, 13.6],
            marker: {
                lineWidth: 2,
                lineColor: Highcharts.getOptions().colors[3],
                fillColor: 'white'
            }
        }]
    });
});
