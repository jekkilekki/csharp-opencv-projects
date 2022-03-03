import cv2
import numpy as np

img = cv2.imread('botw.png')
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
result = np.zeros((img.shape[0], 256), dtype = np.uint8)
hist = cv2.calcHist([img], [0], None, [256], [0, 256])
cv2.normalize(hist, hist, 0, 255, cv2.NORM_MINMAX)

for x, y in enumerate(hist):
  cv2.line(result, (int(x), img.shape[0]), (int(x), img.shape[0] - int(y)), 255)
  
dst = np.hstack([img[:, :, 0], result])

cv2.imshow("dst", dst)
cv2.waitKey(0)
cv2.destroyAllWindows()
