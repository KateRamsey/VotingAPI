# VotingAPI

/Candidates 
◦ Get action
    api/Candidates
◦ GetById action 
    api/Candidates/ID
◦ Post action
    in body: Name, Hometown, District, and Party (all strings)

• /Voters
◦ Post action
      in body: Name, Party (strings)
◦ Get action, with token authentication to prove that you are the voter
    api/Voters/token
◦ Put action, with token authentication to prove that you are the voter
    api/Voters/token
    in body: Name and/or Party to be changed (as strings)

• /Votes 
◦Each voter can cast at most one vote, period.
◦ Post action, with token authentication to show that you are the voter
    api/Votes/token
    in body: Voter ID, Candidate ID
◦ Delete action, with token authentication to show that you are the voter
◦ Get action (which shows all candidates and a number of votes for each)

