mp.events.add('drawWantedLevel', (wantedLevel) => {
    mp.game.gameplay.setFakeWantedLevel(wantedLevel);
});

mp.events.add("addPlayerBlip", (player, blipColor) => {
    if (player.blip == 0) {
        player.createBlip(1);
        player.setBlipColor(isNan(blipColor) ? 0 : color);
        mp.game.invoke(Natives.SET_BLIP_CATEGORY, entity.blip, 7);
    }
})

mp.events.add("removePlayerBlip", (player) => {
    player.blip == 0;
})
