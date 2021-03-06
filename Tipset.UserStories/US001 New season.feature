﻿Feature: US001 New season
	In order to maintain the gaming leauge 
	As an Administrator
	I want to be able to create a new season

@ravendb
Scenario: Create season when number of weeks and players evens up
	Given 4 players
	When I create a new season starting at 2012-08-18 and ending at 2013-05-18
	Then the created season should have 40 rounds
	And there should be one round for every saturday between the start and end date
	And each round should should have 1 player assigned
	And each player should be assigned to every fourth round ordered by player name
	Then the created season should have the following rounds
	| Date       | Players |
	| 2012-08-18 | 1       |
	| 2012-08-25 | 2       |
	| 2012-09-01 | 3       |
	| 2012-09-08 | 4       |
	| 2012-09-15 | 1       |
	| 2012-09-22 | 2       |
	| 2012-09-29 | 3       |
	| 2012-10-06 | 4       |
	| 2012-10-13 | 1       |
	| 2012-10-20 | 2       |
	| 2012-10-27 | 3       |
	| 2012-11-03 | 4       |
	| 2012-11-10 | 1       |
	| 2012-11-17 | 2       |
	| 2012-11-24 | 3       |
	| 2012-12-01 | 4       |
	| 2012-12-08 | 1       |
	| 2012-12-15 | 2       |
	| 2012-12-22 | 3       |
	| 2012-12-29 | 4       |
	| 2013-01-05 | 1       |
	| 2013-01-12 | 2       |
	| 2013-01-19 | 3       |
	| 2013-01-26 | 4       |
	| 2013-02-02 | 1       |
	| 2013-02-09 | 2       |
	| 2013-02-16 | 3       |
	| 2013-02-23 | 4       |
	| 2013-03-02 | 1       |
	| 2013-03-09 | 2       |
	| 2013-03-16 | 3       |
	| 2013-03-23 | 4       |
	| 2013-03-30 | 1       |
	| 2013-04-06 | 2       |
	| 2013-04-13 | 3       |
	| 2013-04-20 | 4       |
	| 2013-04-27 | 1       |
	| 2013-05-04 | 2       |
	| 2013-05-11 | 3       |
	| 2013-05-18 | 4       |

@ravendb
Scenario: Create season when number of weeks and players does not even up
	When I create a new season starting at 2012-08-18 and ending at 2013-05-11 with 4 players
	Then the created season should have the following rounds
	| Date       | Players |
	| 2012-08-18 | 1       |
	| 2012-08-25 | 2       |
	| 2012-09-01 | 3       |
	| 2012-09-08 | 4       |
	| 2012-09-15 | 1       |
	| 2012-09-22 | 2       |
	| 2012-09-29 | 3       |
	| 2012-10-06 | 4       |
	| 2012-10-13 | 1       |
	| 2012-10-20 | 2       |
	| 2012-10-27 | 3       |
	| 2012-11-03 | 4       |
	| 2012-11-10 | 1       |
	| 2012-11-17 | 2       |
	| 2012-11-24 | 3       |
	| 2012-12-01 | 4       |
	| 2012-12-08 | 1       |
	| 2012-12-15 | 2       |
	| 2012-12-22 | 3       |
	| 2012-12-29 | 4       |
	| 2013-01-05 | 1       |
	| 2013-01-12 | 2       |
	| 2013-01-19 | 3       |
	| 2013-01-26 | 4       |
	| 2013-02-02 | 1       |
	| 2013-02-09 | 2       |
	| 2013-02-16 | 3       |
	| 2013-02-23 | 4       |
	| 2013-03-02 | 1       |
	| 2013-03-09 | 2       |
	| 2013-03-16 | 3       |
	| 2013-03-23 | 4       |
	| 2013-03-30 | 1       |
	| 2013-04-06 | 2       |
	| 2013-04-13 | 3       |
	| 2013-04-20 | 4       |
	| 2013-04-27 | 1       |
	| 2013-05-04 | 2       |
	| 2013-05-11 | 3,4     |
