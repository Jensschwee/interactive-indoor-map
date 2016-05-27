function startUpdateTimer() {
    setInterval(function () {
        if (!temporalActive) {
            getRoomsAndDrawRooms();
            if (!roomInfoboxActive)
                infoboxDataUpdate();
        }
    }, 2500);
}