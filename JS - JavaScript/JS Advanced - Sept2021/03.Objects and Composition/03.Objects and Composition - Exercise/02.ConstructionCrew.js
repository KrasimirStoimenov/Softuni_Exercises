function construnct(worker) {
    if (worker.dizziness == true) {
        worker.levelOfHydrated = worker.weight * worker.experience * 0.10;
        worker.dizziness = false;
    }

    return worker;
}

console.log(construnct({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}));
console.log('*'.repeat(10));
console.log(construnct({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
}));
console.log('*'.repeat(10));
console.log(construnct({
    weight: 95,
    experience: 3,
    levelOfHydrated: 0,
    dizziness: false
}));