from urllib.parse import urlparse, parse_qs, unquote

url = "https://myfrontend.com/lander?email=test500%40yopmail.com&oref=https%3A%2F%2Fyopmail.com%2F&token=CfDJ8GQErJ9r%2BLRMoCy3IuJm3Cu%2BYPUTMtgwXN%2BJGtP7iDtPiLJlT4Ph2Vn%2FPjjFfdUsBeykTMEJw8qIHKAQzkUcC3goZ0aWotLFw8tOJcOlZsnTCGrq1z6d%2BXIT1hG8F2sdy9t7nO8Llmq9KrJm%2F8eOEdRg%2BhzlLV15wOzcsr1WBCcUrylfYg74NKkBc1nR9Ieo163QmOhlHGjgrX4e4ibT9KrZ9dueNBCiEmSwKlhyLrE2"

parsed_url = urlparse(url)
query_params = parse_qs(parsed_url.query)

email = query_params.get("email", [None])[0]
token = query_params.get("token", [None])[0]

print("Email:", email)
print("Token:", token)
