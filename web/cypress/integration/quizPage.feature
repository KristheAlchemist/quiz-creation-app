Feature: Quiz Page
  Background: Go to the App
    Given I am on the app

  Scenario: I can see the list of tests
    Then I see 'Loading...'
    Then I see 'Quiz 1'
    Then I see 'Quiz 2'
    Then I see 'Quiz 3'

  Scenario: I can select a quiz
    When I click on 'Quiz 1'
    Then I see 'Why did the chicken cross the road?'
