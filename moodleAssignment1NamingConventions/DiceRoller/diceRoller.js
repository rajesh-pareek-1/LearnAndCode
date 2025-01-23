const readline = require("readline");

function rollDice(diceSides) {
    return Math.floor(Math.random() * diceSides) + 1;
}

function main() {
    const diceSides = 6;
    const readlineInterface = readline.createInterface({
        input: process.stdin,
        output: process.stdout
    });

    function handleDiceRollPrompt() {
        readlineInterface.question("Ready to roll? Enter Q to Quit: ", (userInput) => {
            if (userInput.toLowerCase() !== "q") {
                const result = rollDice(diceSides);
                console.log(`You have rolled a ${result}`);
                handleDiceRollPrompt();
            } else {
                readlineInterface.close();
            }
        });
    }

    handleDiceRollPrompt();
}

main();
