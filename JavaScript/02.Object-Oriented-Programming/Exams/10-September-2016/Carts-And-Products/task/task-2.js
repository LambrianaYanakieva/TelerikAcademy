function solve() {

    class Product {
        constructor(productType, name, price) {
            this.productType = productType;
            this.name = name;
            this.price = price;
        }

        get productType() {
            return this._productType;
        }

        set productType(x) {
            this._productType = x;
        }

        get name() {
            return this._name;
        }

        set name(x) {
            this._name = x;
        }

        get price() {
            return this._price;
        }

        set price(x) {
            this._price = x;
        }
    }

    class ShoppingCart {
        constructor() {
            this.products = [];
        }

        add(product) {

            let p = {
                productType: product.productType,
                name: product.name,
                price: product.price
            }

            if (!(Object.keys(p).every(key => p[key] != undefined))) {
                throw Error('invalid');
            }

            this.products.push(product);

            return this;
        }

        remove(product) {

            let p = {
                productType: product.productType,
                name: product.name,
                price: product.price
            }

            if (!(Object.keys(p).every(key => p[key] != undefined))) {
                throw Error('invalid');
            }

            let index = this.products.findIndex(x =>
                x.name == product.name && x.productType == product.productType &&
                x.price == product.price);

            if (index < 0) {
                throw Error('invalid');
            }

            this.products.splice(index, 1);

        }

        showCost() {

            let sum = 0;

            this.products.forEach(x => sum += x.price);

            return sum;
        }

        showProductTypes() {

            let uniqTypeArray = {};

            this.products.forEach(x => uniqTypeArray[x.productType] = true);

            return Object.keys(uniqTypeArray).sort((a, b) => a > b);
        }

        getInfo() {
            // let object = {};
            // let names = {};
            // this.products.forEach(x => x[uniqueNames] = true);
            // let uniqueNames = Object.keys(uniqueNames);
            // object.products = [];
            // let tempObject = {};

            // for(let i = 0; i < uniqueNames.length; i += 1){
            //     let price = 0;
            //     let quantity = 0;
            //     for(let j = 0; j < this.products.length; j += 1){
            //         if(this.products[j].name == uniqueNames[i]){
            //             price += this.products[j].price;
            //             quantity += 1;       
            //         }
            //     }
            //     tempObject.name = uniqueNames[i];
            //     tempObject.totalPrice = price;
            //     tempObject.quantity = quantity;
            //     object.products.push(tempObject);
            // }
            let p = {};
            this.products.forEach(x => p[x.name] = true);
            let arrayOfUniqNames = Object.keys(p);

            let totalPrice = 0;
            let prices = [];
            let quantitys = [];

            arrayOfUniqNames.forEach(currentName => prices.push(this.products.filter(x => x.name == currentName)
                .reduce((a, b) => a + b.price, 0)));
            arrayOfUniqNames.forEach(currentName => quantitys.push(this.products
                .filter(x => x.name == currentName).length));

            let resultArray = [];

            arrayOfUniqNames.forEach((x, i) => resultArray.push({
                name: arrayOfUniqNames[i],
                totalPrice: prices[i],
                quantity: quantitys[i]
            }));

            resultArray.sort((a, b) => a.name > b.name);

            return {
                totalPrice: this.showCost(),
                products: resultArray
            };
        }
    }

    return {
        Product,
        ShoppingCart
    };
}


module.exports = solve;