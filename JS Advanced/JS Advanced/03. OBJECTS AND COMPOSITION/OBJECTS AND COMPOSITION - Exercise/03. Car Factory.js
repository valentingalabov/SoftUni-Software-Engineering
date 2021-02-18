function heroicInventory(car) {

    const {
        model,
        power,
        carriage,
        color,
        wheelsize
    } = car;

    function getEngine(power) {
        const engines = [
            { power: 90, volume: 1800 },
            { power: 120, volume: 2400 },
            { power: 200, volume: 3500 }]
            .sort((a, b) => a.power - b.power);

        return engines.find(engine => engine.power >= power);
    }

    function getCarriage(carriage, color) {
        return { type: carriage, color }
    }

    function getWheels(wheelsSize) {
        let wheel = Math.floor(wheelsSize) % 2 === 0
            ? Math.floor(wheelsSize) - 1 : Math.floor(wheelsSize);
        
        return Array(4).fill(wheel, 0, 4);
    }

    return {
        model: model,
        engine: getEngine(power),
        carriage: getCarriage(carriage, color),
        wheels: getWheels(wheelsize)
    };
}

console.log(heroicInventory(
    {
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }
));