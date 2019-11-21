$(document).ready(function () {
    $.ajax(
        {
            url: "GetForecastVSalesDataForChart",
            type: "GET",
            dataType: "json",
            data: { },
            success: function (data) {
                CreateChart(data);
            },
            error: function () {
                alert("Data not received");
            }
        });
});

function CreateChart(inputData) {
    var procChart = new Morris.Line(
        {
            element: 'chart',
            data: inputData,
            xkey: ['CropName'],
            ykeys: ['TotalDemandForecast', 'TotalActualSales'],
            labels: ['TotalDemandForecast', 'TotalActualSales'],
            hideHover: 'auto', //hides data unless hovering over
            resize: true, // resize to data size
            parseTime: false //all above are required for chart
        }
    );
}