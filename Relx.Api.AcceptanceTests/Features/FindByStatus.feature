Feature: PetStore Api 

This feature is to verify the FindByStatus endpoint of PetStore Api

Scenario: To verify find by status endpoint
	Given I have a request with 'status' as 'available'
	When I call the '/pet/findByStatus' endpoint
	Then I get '200' status code
