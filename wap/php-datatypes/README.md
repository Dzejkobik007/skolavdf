# **mac-check**

## Úvod

Udelal jsem nejaky testy datatypu, jestli se datatyp nejakým způsobem změní.


## PHP 8.2.1 Results
|In datatype  |In          |Out datatype|Out        |
|------|-------------------|------|-------------------|
|int   |10                 |int   |10                 |
|int   |2                  |int   |2                  |
|int   |10000              |int   |10000              |
|int   |10                 |string|10                 |
|int   |2                  |string|2                  |
|int   |10000              |string|10000              |
|int   |10                 |float |10                 |
|int   |2                  |float |2                  |
|int   |10000              |float |10000              |
|string|asda               |int   |ERROR              |
|string|saaaaaaa           |int   |ERROR              |
|string|ssae2w2fjkloiuhygfd|int   |ERROR              |
|string|asda               |string|asda               |
|string|saaaaaaa           |string|saaaaaaa           |
|string|ssae2w2fjkloiuhygfd|string|ssae2w2fjkloiuhygfd|
|string|asda               |float |ERROR              |
|string|saaaaaaa           |float |ERROR              |
|string|ssae2w2fjkloiuhygfd|float |ERROR              |
|float |102                |int   |102                |
|float |2.0E-7             |int   |0                  |
|float |100                |int   |100                |
|float |102                |string|102                |
|float |2.0E-7             |string|2.0E-7             |
|float |100                |string|100                |
|float |102                |float |102                |
|float |2.0E-7             |float |2.0E-7             |
|float |100                |float |100                |
