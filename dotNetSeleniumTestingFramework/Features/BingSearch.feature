Feature: BingSearch

Basic bing search tests that should validate that site is up and running and user has possibility to search something

@SMOKE
Scenario: Search normal word in bing.com
	Given User is on bing.com webpage
	When User searches for "jak rozliczyć pit za 2021 rok"
	Then First three results contains "PIT"
