import {
  Given, Then,
} from 'cypress-cucumber-preprocessor/steps';

Given('I am on the app', () => {
  cy.visit('/');
});

Given('I am on the profile', () => {
  cy.visit('/profile');
});

Given('I am on the test', () => {
  cy.visit('/test');
});

Then('I see {string}', (label) => {
  cy.get('body')
    .contains(label)
    .should('exist');
});
