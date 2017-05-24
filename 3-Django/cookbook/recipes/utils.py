def format_duration(duration):
    """
    Format a timedelta to be human-readable.

    Argument         Format example
    < 1 minute       "55 seconds"
    < 5 minutes      "3 minutes" OR "3 minutes and 15 seconds"
    < 1 hour         "17 minutes"
    else             "2 hours and 14 minutes"
    """

    if duration is None:
        return None

    t = duration.seconds
    hours = t // 3600
    minutes = (t % 3600) // 60
    seconds = t % 60

    if t < 60:
        return '{} seconds'.format(seconds)
    elif t == 60:
        return '1 minute'
    elif t < 120:
        return '1 minute and {} seconds'.format(seconds)
    elif t < 300:
        if seconds != 0:
            return '{} minutes and {} seconds'.format(minutes, seconds)
        else:
            return '{} minutes'.format(minutes)
    elif t < 3600:
        return '{} minutes'.format(minutes)
    elif t < 7200:
        if minutes != 0:
            return '1 hour and {} minutes'.format(minutes)
        else:
            return '1 hour'
    else:
        if minutes != 0:
            return '{} hours and {} minutes'.format(hours, minutes)
        else:
            return '{} hours'.format(hours)

def convert_to_fraction(x):
	"""
	Convert x to a fraction or mixed fraction.

	Returns an (integer part, numerator, denominator) tuple.
	Possible denominators are 2, 3, 4, 5, 6, 8, and 16.
	"""

	assert x >= 0, "convert_to_fraction requires a nonnegative argument"

	denoms = [2, 3, 4, 5, 6, 8, 16]

	integer_part, numerator, denominator = int(x), 0, 0
	x -= integer_part

	min_diff = x
	for denom in denoms:
		for num in (int(x * denom), int(x * denom) + 1):
			diff = abs(num / denom - x)
			if diff < min_diff:
				min_diff = diff
				numerator, denominator = num, denom

	return integer_part, numerator, denominator

def format_fraction(x):
	"""
	Prints a mixed fraction as human-readable text.

	Expects an input tuple of (integer part, numerator, denominator),
	such as that returned by convert_to_fraction.
	"""

	if x[0] == 0:
		if x[1] == 0:
			return str(0)
		else:
			return '{}/{}'.format(x[1],x[2])
	else:
		if x[1] == 0:
			return str(x[0])
		else:
			return '{} {}/{}'.format(x[0], x[1], x[2])

def format_quantity(quantity, unit, food):
    """
    Beautifies a quantity of an ingredient.
    """

    quantity_print = ''

    if quantity == int(quantity):
        quantity_print = format(round(quantity), 'd')
    else:
        quantity_print = format_fraction(convert_to_fraction(quantity))

    return '{} {} {}'.format(quantity_print, unit, food)
