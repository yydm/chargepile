var Class = {
    // 全局静态类, 用于声明一个新的类并提供构造函数支持
    create: function () {
        return function () { // 返回一个函数, 代表着这个新声明的类的构造函数
            // 一个命名为initialize的函数将被这个类实现作为类的构造函数
            this.initialize.apply(this, arguments); // initialize函数将在你实例化一个变量的时候被调用执行
            //(即上面7个步骤中的第5步)
        };
    }
};

var Current = Class.create();
Current.prototype = {
    currentPointer: 180,
    currentEffectiveMin: 0,
    currentEffectiveMax: 25,
    currentThresholdMin: 0,
    currentThresholdMax: 50,
    CurrentTime: null,
    initialize: function () {

    },
    getCurrentPointer: function () {
        return this.currentPointer;
    },
    getCurrentTime: function () {
        return this.CurrentTime;
    },
    getCurrentEffectiveMax: function () {
        return this.currentEffectiveMax;
    },
    getCurrentEffectiveMin: function () {
        return this.currentEffectiveMin;
    },
    getCurrentThresholdMax: function () {
        return this.currentThresholdMax;
    },
    getCurrentThresholdMin: function () {
        return this.currentThresholdMin;
    },
    setCurrentPointer: function (currentPointer) {
        this.currentPointer = currentPointer;
    },
    setCurrentTime: function (currentTime) {
        this.currentTime = currentTime;
    },
    setCurrentEffectiveMax: function (currentEffectiveMax) {
        this.currentEffectiveMax = currentEffectiveMax;
    },
    setCurrentEffectiveMin: function (currentEffectiveMin) {
        this.currentEffectiveMin = currentEffectiveMin;
    },
    setCurrentThresholdMax: function (currentThresholdMax) {
        this.currentThresholdMax = currentThresholdMax;
    },
    setCurrentThresholdMin: function (currentThresholdMin) {
        this.currentThresholdMin = currentThresholdMin;
    }
};

var Voltage = Class.create();
Voltage.prototype = {
    voltagePointer: 580,
    voltageEffectiveMin: 0,
    voltageEffectiveMax: 150,
    voltageThresholdMin: 0,
    voltageThresholdMax: 300,
    VoltageTime:null,
    initialize: function () {

    },
    getVoltagePointer: function () {
        return this.voltagePointer;
    },
    getVoltageTime: function () {
        return this.VoltageTime;
    },
    getVoltageEffectiveMax: function () {
        return this.voltageEffectiveMax;
    },
    getVoltageEffectiveMin: function () {
        return this.voltageEffectiveMin;
    },
    getVoltageThresholdMax: function () {
        return this.voltageThresholdMax;
    },
    getVoltageThresholdMin: function () {
        return this.voltageThresholdMin;
    },
    setVoltagePointer: function (voltagePointer) {
        this.voltagePointer = voltagePointer;
    },
    setVoltageTime: function (voltageTime) {
        this.VoltageTime = voltageTime;
    },
    setVoltageEffectiveMax: function (voltageEffectiveMax) {
        this.voltageEffectiveMax = voltageEffectiveMax;
    },
    setVoltageEffectiveMin: function (voltageEffectiveMin) {
        this.voltageEffectiveMin = voltageEffectiveMin;
    },
    setVoltageThresholdMax: function (voltageThresholdMax) {
        this.voltageThresholdMax = voltageThresholdMax;
    },
    setVoltageThresholdMin: function (voltageThresholdMin) {
        this.voltageThresholdMin = voltageThresholdMin;
    }
};
