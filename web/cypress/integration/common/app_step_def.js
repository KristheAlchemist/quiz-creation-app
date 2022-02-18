import {
  Given, When, Then,
} from 'cypress-cucumber-preprocessor/steps';

Given('I am on the app', () => {
  cy.visit('/');
});

When('I click on {string}', (label) => {
  cy.get('body')
    .contains(label)
    .click();
});

Then('I see {string}', (label) => {
  cy.get('body')
    .contains(label)
    .should('exist');
});
