const fs = require('fs');
const readline = require('readline');
const path = require('path');

const ERROR_INVALID_CODE = "Invalid Country Code or No Data Available.";
const COUNTRY_DATA_FILE = path.join(__dirname, 'countryAdjacencyMap.json');

function loadCountryData(filePath) {
    try {
        const data = fs.readFileSync(filePath, 'utf8');
        return JSON.parse(data);
    } catch (error) {
        console.error("Error reading country data file:", error.message);
        process.exit(1);
    }
}

function processUserInput(countryCode, countryAdjacencyMap) {
    countryCode = countryCode.toUpperCase();

    if (countryAdjacencyMap[countryCode]) {
        const adjacentCountries = countryAdjacencyMap[countryCode];
        console.log(`Adjacent countries to ${countryCode}: ${adjacentCountries.join(', ')}`);
    } else {
        console.log(ERROR_INVALID_CODE);
    }
}

const readLineInterface = readline.createInterface({
    input: process.stdin,
    output: process.stdout,
});

function main() {
    const countryAdjacencyMap = loadCountryData(COUNTRY_DATA_FILE);

    readLineInterface.question("Enter a Country Code (e.g., IN, US, NZ): ", (countryCode) => {
        processUserInput(countryCode, countryAdjacencyMap);
        readLineInterface.close();
    });
}

main();
