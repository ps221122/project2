let carts = document.querySelectorAll(".add");

let products = [
    {
        name: "Gae CityGo C7",
        tag: "fiets1",
        price: 679,
        inCart: 0
    },
    {
        name: "Pelikaan Carry On Lady",
        tag: "fiets2",
        price: 769,
        inCart: 0
    },
    {
        name: "Allegra Voorwielmotor",
        tag: "fiets3",
        price: 999,
        inCart: 0
    },
    {
        name: "Gazelle Orange C7+ HMB 2020",
        tag: "fiets4",
        price: 2199,
        inCart: 0

    },
    {
        name: "Stromer ST3 2021 Sport",
        tag: "fiets5",
        price: 7090,
        inCart: 0

    }
];

for (let i = 0; i < carts.length; i++) {
    carts[i].addEventListener("click", () => {
        cartNumbers(products[i]);
        totalCost(products[i]);
    })

}
function onLoadCartNumbers() {
    let productNumbers = localStorage.getItem('cartNumbers');

    if (productNumbers) {
        document.querySelector(".cart span").textContent = productNumbers;
    }
}

function cartNumbers(product) {

    let productNumbers = localStorage.getItem('cartNumbers');

    productNumbers = parseInt(productNumbers);

    if (productNumbers) {
        localStorage.setItem("cartNumbers", productNumbers + 1);
        document.querySelector(".cart span").textContent = productNumbers - 1;
    }
    else {
        localStorage.setItem("cartNumbers", 1);
        document.querySelector(".cart span").textContent = 1;
    }

    setItems(product);

}
function setItems(product) {
    let cartItems = localStorage.getItem('productsInCart');
    cartItems = JSON.parse(cartItems);

    if (cartItems != null) {
        if (cartItems[product.tag] == undefined) {
            cartItems = {
                ...cartItems, [product.tag]: product
            }
        }
        cartItems[product.tag].inCart += 1;
    }
    else {
        product.inCart = 1;
        cartItems = {
            [product.tag]: product
        }
    }
    //console.log("the item selected is ", cartItems);
    localStorage.setItem("productsInCart", JSON.stringify(cartItems));
}

function totalCost(product) {
    // console.log(product.price);
    let cartCost = localStorage.getItem('totalCost');


    if (cartCost != null) {
        cartCost = parseInt(cartCost);
        localStorage.setItem("totalCost", cartCost + product.price);
    }
    else {
        localStorage.setItem("totalCost", product.price);
    }
}


function displayCart() {
    let cartItems = localStorage.getItem("productsInCart");
    cartItems = JSON.parse(cartItems);
    let productContainer = document.querySelector(".products");
    let cartCost = localStorage.getItem('totalCost');

    if (cartItems && productContainer) {
        productContainer.innerHTML = "";
        Object.values(cartItems).map(item => {
            productContainer.innerHTML += `
            <div class="product">
            <div class="items">
            <ion-icon class="close" name="close-circle"></ion-icon>
            <img class="cart-items" src="./assets/imgs/fiets/${item.tag}.jpg">
            <span class="span">${item.name}</span>
       
        </div>
        <div class="price prijs">&#8364; ${item.price},00</div>
        <div class="quantity aantal">
        <ion-icon onclick="myDecrease()" class="decrease" style="margin: auto;"  name="arrow-dropdown-circle">
        </ion-icon><span>${item.inCart}</span>
        <ion-icon onclick="myDecrease()" class="increase"   style="margin: auto;" name="arrow-dropup-circle"></ion-icon>
        </div>
        <div class="total">&#8364; ${item.inCart * item.price},00</div>
        </div>
        <br>
            `
        });

        productContainer.innerHTML += `
        <div class="basketTotalContainer">
        <h4 class="basketTotalTitel">
        Totaal: </h4>
        <h4 class="basketTotal">&#8364;${cartCost},00</h4 >
        `;

        productContainer.innerHTML += `    
        <div class="koopBtn">
        <button onclick="bestelBtn()"  class="buyBtn">
        Bestellen</button>
        </div>
        
        `;
    }
}


function bestelBtn() {
    localStorage.clear();
    location.reload();
    alert("Jouw brstelling was verzonden");

}


displayCart();
onLoadCartNumbers();

