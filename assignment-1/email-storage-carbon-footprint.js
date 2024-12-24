const CARBON_EMISSION_PER_KG = {
    INBOX: 0.02,
    SENT: 0.05,
    SPAM: 0.03
};

const EmailCategory = Object.freeze({
    INBOX: 'INBOX',
    SENT: 'SENT',
    SPAM: 'SPAM'
});

class EmailInfo {
    constructor(emailId, emailSource, inboxFolderSize, sentFolderSize, spamFolderSize) {
        this.emailId = emailId;
        this.emailSource = emailSource;
        this.inboxFolderSize = inboxFolderSize;
        this.sentFolderSize = sentFolderSize;
        this.spamFolderSize = spamFolderSize;
    }
}

function calculateCarbonAmount(emailFolderSizeInKG, category) {
    const emissionRate = CARBON_EMISSION_PER_KG[category];
    if (emissionRate === undefined) {
        throw new Error(`Invalid email category: ${category}`);
    }
    return emissionRate * emailFolderSizeInKG;
}

function printCarbonFootprint(emailId, emailSource, inboxCarbon, sentCarbon, spamCarbon) {
    console.log(`Email ID: ${emailId}`);
    console.log(`Source: ${emailSource}`);
    console.log(`Inbox Carbon: ${inboxCarbon.toFixed(2)} KG`);
    console.log(`Sent Carbon: ${sentCarbon.toFixed(2)} KG`);
    console.log(`Spam Carbon: ${spamCarbon.toFixed(2)} KG`);
}

function getCarbonFootprint(emailInfo) {
    const inboxCarbon = calculateCarbonAmount(emailInfo.inboxFolderSize, EmailCategory.INBOX);
    const sentCarbon = calculateCarbonAmount(emailInfo.sentFolderSize, EmailCategory.SENT);
    const spamCarbon = calculateCarbonAmount(emailInfo.spamFolderSize, EmailCategory.SPAM);

    printCarbonFootprint(emailInfo.emailId, emailInfo.emailSource, inboxCarbon, sentCarbon, spamCarbon);
}

const emailInfo = new EmailInfo('rajesh.pareek@intimetec.com', 'outlook', 50.0, 5.0, 1.0);
getCarbonFootprint(emailInfo);
