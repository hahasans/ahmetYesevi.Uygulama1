import requests
import RPi.GPIO as GPIO
import time

mseq=0
while(1):
    resp = requests.get('http://dunsev.org/api/Uygulama')
    if resp.status_code != 200:
        raise ApiError('GET /tasks/ {}'.format(resp.status_code))
    seq = [x['Date']for x in resp.json()]
    for x in resp.json():
        if x['Date']==max(seq):
            mseq=x['Data']
            GPIO.setmode(GPIO.BCM)
            GPIO.setwarnings(False)
            GPIO.setup(18,GPIO.OUT)
            print(mseq)
            if int(mseq)<50:
               GPIO.setup(18,GPIO.HIGH)
               time.sleep(5)
            else:
               GPIO.setup(18,GPIO.LOW)
               time.sleep(5)  

