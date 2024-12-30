const readline = require('readline');

function getNumberOfDigits(number) {
    let numDigits = 0;
    let currentNumber = number;

    while (currentNumber > 0) {
        numDigits++;
        currentNumber = Math.floor(currentNumber / 10);
    }
    return numDigits;
}

function isArmstrongNumber(number) {
    let sumOfPowers = 0;
    const numDigits = getNumberOfDigits(number);
    let currentNumber = number;

    while (currentNumber > 0) {
        const digit = currentNumber % 10;
        sumOfPowers += Math.pow(digit, numDigits);
        currentNumber = Math.floor(currentNumber / 10);
    }

    return sumOfPowers === number;
}

const readlineInterface = readline.createInterface({
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
