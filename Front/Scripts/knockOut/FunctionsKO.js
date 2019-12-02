function reflectionObject(source, target) {
    var arrayKeys = Object.keys(source);
    for (var i = 0; i < arrayKeys.length; i++) {
        target[arrayKeys[i]](source[arrayKeys[i]]);
    }
    return target;
}