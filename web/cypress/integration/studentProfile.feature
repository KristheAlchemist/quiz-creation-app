Feature: Student Profile
  Background: Go to the App
    Given I am on the student list

  Scenario: I can see the student list
    Then I see 'Loading...'
    Then I see 'Students'
    Then I see 'Kris Robinson'

  Scenario: I can select a student
    When I click on 'Kris Robinson'
    Then I see 'Loading...'
    Then I see 'Kris Robinson'