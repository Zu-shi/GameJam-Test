
import math


G = 6.67 * math.pow(10,-11)
m_earth = 5.97* math.pow(10,24)
spery = 3.15 * math.pow(10,7)
m = m_earth


r = input("Input the distance from the sun in AU")

r = r * 149597870700 #convert AU to m

try:
	m = input("Input the mass (hit enter for Earth mass)")
except:
	m = m_earth

v_earth = math.sqrt(G*m_earth/r)

orbitalvelocity = math.sqrt(G*m/r)
orbitalvelocityratio = orbitalvelocity/v_earth
period = 2 * math.pi * math.sqrt(math.pow(r, 3) / G / m)
period_year = period / spery

print period

print "The orbital period (years):  "
print period_year

print "The orbital velocity (m/s):  "
print orbitalvelocity
print "the orbital velocity in relation to earth:  "
print orbitalvelocityratio


