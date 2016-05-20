function TemporalDateRangePicker() {
    $("#DRP").hide();

    $(function () {
        $('input[name="daterangepicker"]').daterangepicker({
            drops: "up",
            opens: "left",
            timePicker24Hour: true,
            linkedCalendars: false,
            timePicker: true,
            timePickerIncrement: 15,
            startDate: "24/03/2016 00:00",
            locale: {
                format: 'DD/MM/YYYY h:mm'
            }
        });
    });

    $('#daterangepicker').on('apply.daterangepicker', function (ev, picker) {
        TemporalUpdater();
    });
}

function TemporalUpdater() {
    function onSuccess(response) {
        colletionOfRoomsOnMap = JSON.parse(response);
        drawRoomsForeground(colletionOfRoomsOnMap);
        splitRoomsIntoBarchart(colletionOfRoomsOnMap);
    }

    var dateResult = document.getElementById("daterangepicker").value;
    var dateResultArray = dateResult.split(" - ");
    var fromDateResult = dateResultArray[0].split("/");
    var toDateResult = dateResultArray[1].split("/");


    var fromDate = fromDateResult[1] + "/" + fromDateResult[0] + "/" + fromDateResult[2];
    var toDate = toDateResult[1] + "/" + toDateResult[0] + "/" + toDateResult[2];

    PageMethods.GetDrawableTemporalFloorReadings(currentFloorLevel, fromDate, toDate, onSuccess);

    if (buildingButton._currentState.stateName === "toggled") {
        drawBuildingInfoBox();
    } else {
        drawFloorInfobox(currentFloorLevel);
    }
}