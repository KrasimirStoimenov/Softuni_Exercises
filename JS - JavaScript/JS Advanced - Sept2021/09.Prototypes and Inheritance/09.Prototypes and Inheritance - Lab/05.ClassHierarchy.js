function solve() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        changeUnits(value) {
            this.units = value;
        }

        convertParameters(param) {
            switch (this.units) {
                case 'm':
                    param /= 10;
                    break;
                case 'mm':
                    param *= 10;
                    break;
            }
            return param;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }
    }
    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this._radius = radius;
        }

        get area() {
            return Math.PI * this.radius * this.radius;
        }

        get radius() {
            return this.convertParameters(this._radius);
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`;
        }
    }
    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this._width = width;
            this._height = height;
        }

        get area() {
            return this.width * this.height;
        }

        get width() {
            return this.convertParameters(this._width);
        }

        get height() {
            return this.convertParameters(this._height);
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}

let func = solve();
let c = new func.Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new func.Rectangle(3, 4, 'mm');
console.log(r.area); // 1200 
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()) // Figures units: mm Area: 7853.981633974483 - radius: 50
