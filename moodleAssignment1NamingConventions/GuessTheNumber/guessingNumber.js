const MAX_NUMBER = 100;

function isValidGuess(userGuess) {
    const guessedNumber = parseInt(userGuess, 10);
    return !isNaN(guessedNumber) && guessedNumber >= 1 && guessedNumber <= MAX_NUMBER;
}

function promptForGuess(readlineInterface, targetNumber, totalGuesses) {
    readlineInterface.question("Guess a number between 1 and 100: ", (userInput) => {
        if (!isValidGuess(userInput)) {
            console.log("Invalid input. Please enter a number between 1 and 100.");
            promptForGuess(readlineInterface, targetNumber, totalGuesses);
            return;
        }

        totalGuesses++;
        const guessedNumber = parseInt(userInput, 10);

        if (guessedNumber < targetNumber) {
            console.log("Too low. Try again.");
            promptForGuess(readlineInterface, targetNumber, totalGuesses);
        } else if (guessedNumber > targetNumber) {
            console.log("Too high. Try again.");
            promptForGuess(readlineInterface, targetNumber, totalGuesses);
        } else {
            console.log(`Congratulations! You guessed the number in ${totalGuesses} attempts.`);
            readlineInterface.close();
        }
    });
}

function playGuessingGame() {
    const targetNumber = Math.floor(Math.random() * MAX_NUMBER) + 1;
    let totalGuesses = 0;

    const readline = require("readline");
    const readlineInterface = readline.createInterface({
        input: process.stdin,
        output: process.stdout
    });

    promptForGuess(readlineInterface, targetNumber, totalGuesses);
}

playGuessingGame();
