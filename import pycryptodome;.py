from Crypto.Util import number

def generate_prime_number(bits):
    return number.getPrime(bits)

# Задаем желаемую длину простого числа (в битах)
desired_length = 256

# Генерируем простое число заданной длины
prime_number = generate_prime_number(desired_length)

print("Сгенерированное простое число длиной {} бит: {}".format(desired_length, prime_number))