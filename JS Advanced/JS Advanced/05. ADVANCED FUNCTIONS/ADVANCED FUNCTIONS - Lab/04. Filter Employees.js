function solve(data, criteria) {
    let employees = JSON.parse(data);
    let token = criteria.split('-');
    let key = token[0];
    let value = token[1];

    let result = [];
    let counter = 0;

    for (let employ of employees) {
        if (employ[key] == value) {
            result.push(`${counter}. ${employ[`first_name`]} ${employ[`last_name`]} - ${employ[`email`]}`);
            counter++;
        }
    }

    return result.join('\n');
}

solve(`[{
    "id": "1",
    "first_name": "Ardine",
    "last_name": "Bassam",
    "email": "abassam0@cnn.com",
    "gender": "Female"
  }, {
    "id": "2",
    "first_name": "Kizzee",
    "last_name": "Jost",
    "email": "kjost1@forbes.com",
    "gender": "Female"
  },  
{
    "id": "3",
    "first_name": "Evanne",
    "last_name": "Maldin",
    "email": "emaldin2@hostgator.com",
    "gender": "Male"
  }]`,
    'gender-Female'
);
