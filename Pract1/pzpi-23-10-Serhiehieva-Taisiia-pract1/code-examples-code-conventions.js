//=====В.1 Читабельність коду та назви змінних=====
// Погано 
let x = 5; 
let y = 10;

// Добре
let userAge = 5;
let maxUsers = 10;

//=====В.2 Const, let та var=====
var oldVar = "старий"; // не рекомендується
let userName = "Anna"; // змінна
const PI = 3.14; // константа

//=====В.3 Форматування та відступи=====
// Погано
function sum(a,b){return a+b;}
// Добре
function sum(a, b) {
return a + b; 
}

//=====В.4 Строге і нестроге порівняння=====
console.log(5 == "5"); // true
console.log(5 === "5");  // false


//=====В.5 Принцип DRY (Don’t Repeat Yourself)=====
// Погано
console.log("Hello");
console.log("Hello");
// Добре
function greet() { console.log("Hello"); } greet();


//=====В.6 Використання сучасних можливостей ES6+=====
//Старе
function add(a, b) {
  return a + b;
}
//Нове
const add = (a, b) => a + b;

//=====В.7 Умовні оператори та короткі записи=====
const isLoggedIn = true;
const message = isLoggedIn ? "Ви в системі" : "Будь ласка, увійдіть";

console.log(message);

//=====В.8 Деструктуризація об’єктів та масивів=====
const user = {name: "Anna", age: 20};
const {name, age} = user;
console.log(name, age);

const arr = [1, 2, 3];
const [first, second] = arr;
console.log(first, second);

//=====В.9 Обробка помилок=====
try {
    JSON.parse("неправильний JSON");
} catch (error) {
    console.error("Помилка:", error.message);
}

//=====В.10 Коментарі=====
/**
 * Функція обчислює площу прямокутника
 * @param {number} width - ширина
 * @param {number} height - висота
 * @returns {number} площа
 */
function rectangleArea(width, height) {
    return width * height;
}

//=====В.11 Уникання магічних чисел=====
//Погано
let discountedPrice1 = 500 * 0.4;

//Добре
const DISCOUNT_RATE = 0.4; // знижка 20%
let originalPrice = 500;
let discountedPrice2 = originalPrice * (1 - DISCOUNT_RATE);

//=====В.12 Асинхронність у JS=====
async function fetchData() {
    try {
        let response = await fetch("https://api.example.com/data");
        let data = await response.json();
        console.log(data);
    } catch (error) {
        console.error("Помилка запиту:", error);
    }
}

//=====В.13 Модулі та структура кода=====
// math.js
export const add = (a, b) => a + b;

// main.js
import { add } from './math.js';
console.log(add(5, 3));

//=====В.14 Мар та Set=====
const mySet = new Set([1, 2, 2, 3]);
console.log(mySet); // Set {1, 2, 3}

const myMap = new Map();
myMap.set("name", "Anna");
console.log(myMap.get("name")); // Anna

//=====В.15 Інструменти для перевірки стилю=====
//# Перевірка коду 
//npx eslint script.js 
//# Автоматичне форматування 
//npx prettier --write script.js

//=====В.16 Unit-тести та TDD у JS=====
// Jest
test("додає два числа", () => {
    expect(2 + 3).toBe(5);
});

// Mocha
const assert = require("assert");

function multiply(a, b) {
    return a * b;
}

describe("multiply", function() {
    it("множить два додатних числа", function() {
        assert.strictEqual(multiply(2, 3), 6);
    });

    it("множить на нуль", function() {
        assert.strictEqual(multiply(5, 0), 0);
    });
});

