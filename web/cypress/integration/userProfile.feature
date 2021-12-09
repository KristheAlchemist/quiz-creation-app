Feature: User Profile
  Background: Go to the App
    Given I am on the profile

  Scenario: I can see the user profile
    Then I see 'Kris Robinson'
