const inputHandler = require('readline');

function getNumberOfDigits(number) {
    let digitCount = 0;
    let currentNumber = number;

    while (currentNumber > 0) {
        digitCount++;
        currentNumber = Math.floor(currentNumber / 10);
    }
    return digitCount;
}

function isArmstrongNumber(number) {
    let sumOfPowers = 0;
    const digitCount = getNumberOfDigits(number);
    let currentNumber = number;

    while (currentNumber > 0) {
        const digit = currentNumber % 10;
        sumOfPowers += Math.pow(digit, digitCount);
        currentNumber = Math.floor(currentNumber / 10);
    }

    return sumOfPowers === number;
}

const readlineInterface = inputHandler.createInterface({
    input: process.stdin,
    output: process.stdout
});

readlineInterface.question("Please enter a number to check if it is an Armstrong number: ", (userInput) => {
    const number = parseInt(userInput, 10);

    if (isArmstrongNumber(number)) {
        console.log(`${number} is an Armstrong number.`);
    } else {
        console.log(`${number} is not an Armstrong number.`);
    }

    readlineInterface.close();
});
