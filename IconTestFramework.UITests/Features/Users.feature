  Feature: User API - List Users
  As an API client
  I want to request a list of users by page number
  So that I can retrieve a paginated list of users from the API

  Background:
    Given the API endpoint to list users is "/api/users"
    And the API is up and running
    And I have a valid API token

  Scenario Outline: Successfully retrieve a list of users for a specific page
    When I send a GET request to "/api/users" with the query parameter 'page' set to '<PageNumber>'
    Then the response status code should be 200    
    And The page number returned matches with the one specified in the URL
    And the response should contain a list of users of 6
    And the list should contain users for page <PageNumber>
   
   Examples: 
   | PageNumber | FirstName | LastName | Email                  | Avatar                 |
   | 1          | Janet     | Weaver   | janet.weaver@reqres.in | img/faces/2-image.jpg  |
   | 2          | Byron     | Fields   | byron.fields@reqres.in | img/faces/10-image.jpg |

   
   Scenario: Non users are retrieve for a nonexistent page
   When I send a GET request to "/api/users" with the query parameter 'page' set to '12'
   Then the response status code should be 200    
    And The page number returned matches with the one specified in the URL
    And The response should not contain users


