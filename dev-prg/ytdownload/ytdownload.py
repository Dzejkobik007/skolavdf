import sys
import os
import argparse
if os.name == 'nt':
    winrunning = True
else:        
    winrunning = False
print("[main] You are running on {}".format(sys.platform))
def checkconnection():
    if winrunning:
        if os.system("ping 1.1.1.1 >nul 2>&1"):
            print("[main] Network problems, exiting...")
            quit(1)
    else:
        if os.system("ping -c 2 1.1.1.1 > /dev/null"):
            print("[main] Network problems, exiting...")
            quit(1)
def askyesno():
    while True:
        answer = input("[main] Enter yes or no: ") 
        if answer == "yes": 
            return True
        elif answer == "no": 
            return False 
        else: 
            pass
checkconnection()
try:
  import youtube_dl
except:
  print("[main] Some libraries not installed, install?")
  if askyesno():
    try:
        os.system("{} -m pip install youtube_dl".format(sys.executable))
        import youtube_dl
    except:
        print("[main] Error when installing, exiting...")
        quit(1)
  else:
       print("[main] Missing library, exiting...")
       quit(1)
  
  
parser = argparse.ArgumentParser(description='Process some integers.')
parser.add_argument('-u', dest='url', action='store',
                    help='Specify download url')
parser.add_argument('-f', dest='filename', action='store',
                    help='Specify name of file')
parser.add_argument('-p', dest='path', action='store',
                    help='Specify path to download folder')
parser.add_argument('--video',
                    help='Specify if download with video', action='store_true')
args = parser.parse_args()
def getinfo(video_url):
    return youtube_dl.YoutubeDL().extract_info(
        url = video_url,download=False
    )
def download(video_url):
    if args.video:
        fformat = "mp4"
    else:
        fformat = "mp3"
    video_info = getinfo(video_url)
    print("[main] Video title: {}".format(video_info['title']))
    cwd = os.getcwd()+"/"
    if args.path:
        cwdinput = args.path
    else:
        cwdinput = input("[main] Path: [{}] ".format(cwd))
    if cwdinput:
        cwd = cwdinput
    filename = f"{video_info['title']}.{fformat}"
    if args.filename:
        filenameinput = args.filename
    else:
        filenameinput = input("[main] Filename: [{}] ".format(filename))
    if filenameinput:
        filename = filenameinput
        
    options={
        'format':'bestaudio/best',
        'keepvideo':args.video,
        'outtmpl':cwd+"/"+filename,
    }


    with youtube_dl.YoutubeDL(options) as ydl:
        ydl.download([video_info['webpage_url']])

    print("[main] Download complete... {}".format(filename))


if __name__=='__main__':
    if args.url:
        video_url = args.url
    else:
        video_url = input("Url:")
    download(video_url)
