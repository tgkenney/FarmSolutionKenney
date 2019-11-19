$(document).ready(function() {
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
            xKey: ['CropName'],
            yKeys: ['TotalDemandForecast', 'TotalActualSales'],
            labels: ['TotalDemandForecast', 'TotalActualSales'],
            hideHover: 'auto',
            resize: true,
            parseTime: false
        }
    );
}