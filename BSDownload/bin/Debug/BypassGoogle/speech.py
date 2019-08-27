import speech_recognition as sr
import sys

if(len(sys.argv)) == 2:
	r = sr.Recognizer()
	with sr.AudioFile(sys.argv[1]) as source:
		audio = r.listen(source)

print(r.recognize_google(audio, language="en_EN"))