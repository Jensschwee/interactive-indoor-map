setInterval(function () {
    if (!temporalActive) {
        getRoomsAndDrawRooms();
        infoboxDateUpdate();
    }
}, 2500);