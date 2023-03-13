from flask import Flask


app = Flask(__name__)


@app.route('/')
def main():
    return "<h1>Hello world!</h1><br><a href='/index'>to the 2nd page</a>"

# Передача аргументов через адресную строку
@app.route('/index/<x>/<y>')
def index(x, y):
    return f"Результат: {float(x)+float(y)}"


if __name__ == '__main__':
        app.run()

