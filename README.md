# Grouping Service

A web application that combines single users to groups of N minimizing the difference in two values: skill and remoteness.

The logic for the group selection:
- Try to find a free group for a user with a range 20% (by default, can be changed in appsettings.json) to skill and remoteness.
- If we can't find any not started groups - create a new one.
- Connect user to the Group.

## How to run
```sh
docker-compose build
docker-compose up
```

### Usage
- AddUser: http://localhost:5000/addUser?name=[name]&skill=[double]&remoteness=[int]
- Generate Report to file:  http://localhost:5000/report
- All Groups: http://localhost:5000/groups